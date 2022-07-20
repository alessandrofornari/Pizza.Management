using Dapper;
using MediatR;
using Pizza.Management.Domain.PizzaManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pizza.Management.Application.PizzaManagement
{
    public class GetNextOrderQuery : IRequest<GetOrderQueryResult>
    {    
    }

    public class GetNextOrderQueryHandler : IRequestHandler<GetNextOrderQuery, GetOrderQueryResult>
    {
        private readonly IDbConnection dbConnection;

        public GetNextOrderQueryHandler(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<GetOrderQueryResult> Handle(GetNextOrderQuery request, CancellationToken cancellationToken)
        {
            var result = (await dbConnection
                                .QueryAsync<GetOrderQueryResult>("SELECT TOP 1[Order].Id AS Id, [Order].Code AS OrderCode, [Customer].[Name] AS CustomerName " +
                                                                 "FROM [dbo].[Order] " +
                                                                 "INNER JOIN [dbo].[PizzaOrder] on [PizzaOrder].[OrderId] = [Order].[Id] " +
                                                                 "INNER JOIN [dbo].[Pizza] on [Pizza].[Id] = [PizzaOrder].[PizzaId] " +
                                                                 "INNER JOIN [dbo].[Customer] on [Order].[CustomerId] = [Customer].[Id] " +
                                                                 "WHERE [Order].[IsDelivered] = 0 " +
                                                                 "ORDER BY [Order].[Id]")
                    ).FirstOrDefault();


            if (result == null)
                throw new InvalidOperationException("No Order Available"); //TODO: manage the exception maybe with a middleware

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("orderId", result.Id);

            var pizzaOrders = (await dbConnection
                                .QueryAsync<PizzaNameNumberDTO>("SELECT [Pizza].[Name], [PizzaOrder].[Number] " +
                                                                 "FROM [dbo].[Order] " +
                                                                 "INNER JOIN [dbo].[PizzaOrder] on [PizzaOrder].[OrderId] = [Order].[Id] " +
                                                                 "INNER JOIN [dbo].[Pizza] on [Pizza].[Id] = [PizzaOrder].[PizzaId] " +
                                                                 "WHERE [Order].[Id] = @orderId ", parameters)
                    ).ToList();

            result.PizzaOrders = pizzaOrders;

            return result;

        }
    }

    public class GetOrderQueryResult
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public string CustomerName { get; set; }
        public List<PizzaNameNumberDTO> PizzaOrders { get; set; }
    }

}
