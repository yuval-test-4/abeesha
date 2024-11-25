using Abeesha.APIs.Common;
using Abeesha.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abeesha.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class OrderFindManyArgs : FindManyInput<Order, OrderWhereInput> { }
