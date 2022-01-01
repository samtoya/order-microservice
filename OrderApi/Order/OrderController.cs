using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Common;

namespace OrderApi.Order
{
    [ApiController]
    [Route("/api/orders")]
    [ApiVersion("1.0")]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _orderRepository;
        
        public OrderController(ILogger<OrderController> logger, IOrderRepository orderRepository, IMapper mapper)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ApiResponse<IEnumerable<OrderDomain>>> GetAllOrders()
        {
            _logger.LogInformation("Get all orders");
            var orders = _orderRepository.GetAll();
            var domains = orders.Result.Select(order => _mapper.Map<OrderDomain>(order))
                .ToList();
            var apiResponse = new ApiResponse<IEnumerable<OrderDomain>>()
            {
                Data = domains,
                Success = true,
                Message = "Retrieved all orders successfully!",
                ErrorMessages = null
            };
            return Ok(apiResponse);
        }

        [HttpGet("/api/orders/{orderId}")]
        public ActionResult<ApiResponse<OrderDomain>> GetOrder(String orderId)
        {
            _logger.LogInformation("Get order by id ::: " + orderId);
            var order = _orderRepository.GetById(orderId).Result;
            var domain = _mapper.Map<OrderDomain>(order);
            var apiResponse = new ApiResponse<OrderDomain>()
            {
                Data = domain,
                Success = true,
                Message = "Retrieved order successfully!",
                ErrorMessages = null
            };
            return Ok(apiResponse);
        }

        [HttpPost]
        public ActionResult<ApiResponse<OrderDomain>> CreateOrder(OrderDto dto)
        {
            _logger.LogInformation("Create New Order From Dto ::: " + dto);
            var order = _orderRepository.CreateOrderFromDto(dto).Result;
            var domain = _mapper.Map<OrderDomain>(order);
            var apiResponse = new ApiResponse<OrderDomain>()
            {
                Data = domain,
                Success = true,
                Message = "Order was created successfully",
                ErrorMessages = null
            };
            
            return Created("/api/orders/" + order.Id, apiResponse);
        }

        [HttpDelete("/api/orders/{orderId}")]
        public ActionResult<ApiResponse<Boolean>> DeleteOrder(String orderId)
        {
            _logger.LogInformation("Delete order by id ::: " + orderId);
            var isDeleted = _orderRepository.DeleteOrderById(orderId);
            var apiResponse = new ApiResponse<Boolean>();
            if (!isDeleted.Result)
            {
                apiResponse.Data = false;
                apiResponse.Success = false;
                apiResponse.ErrorMessages = new[]
                {
                    "Error deleting order with id: " + orderId
                };

                return UnprocessableEntity(apiResponse);
            }
            
            apiResponse.Data = true;
            apiResponse.Success = true;
            apiResponse.ErrorMessages = null;

            return Ok(apiResponse);
        }
    }
}
