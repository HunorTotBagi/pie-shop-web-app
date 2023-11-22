using BethanysPieShop.Models;
using BethanysPieShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BethanysPieShop.Pages
{
    public class CheckoutPageModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

		public CheckoutPageModel(IOrderRepository orderRepository, IShoppingCart shoppingCart)
		{
			_orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
		}

		private readonly IShoppingCart _shoppingCart;

        [BindProperty]
        public Order Order { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
                ModelState.AddModelError("", "Your cart is empty, add some pie first");

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(Order);
                _shoppingCart.ClearCart();
                return RedirectToPage("CheckoutCompletePage");
            }
            return Page();
        }
    }
}