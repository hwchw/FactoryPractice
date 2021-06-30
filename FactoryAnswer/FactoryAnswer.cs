using System;

namespace FactoryAnswer
{

	class FactoryAnswer
	{
		static void Main(string[] args)
		{
			var store = new TaipeiPizzaStore();
			store.OrderPizza("StinkyTofu");
			Console.ReadLine();
		}
	}

	public abstract class PizzaStore
	{
		public Pizza OrderPizza(string pizzaType)
		{
			var pizza = CreatePizza(pizzaType);

			pizza.Prepare();
			pizza.Bake();
			pizza.Cut();
			pizza.Box();
			return pizza;
		}

		protected abstract Pizza CreatePizza(string pizzaType);
	}

	class TaipeiPizzaStore : PizzaStore
	{
		protected override Pizza CreatePizza(string pizzaType)
		{
			switch (pizzaType)
			{
				case "LoBaBun":
					return new LoBaBunPizza();
				case "StinkyTofu":
					return new StinkyTofuPizza();
				default:
					return null;
			}
		}
	}

	public abstract class Pizza
	{
		public void Prepare()
		{
			Console.WriteLine("Add Sauce");
			Console.WriteLine("Add Cheese");
			Console.WriteLine("Add Pepper");
		}
		public virtual void Bake() { Console.WriteLine("Bake for 20 minutes"); }
		public virtual void Cut() { Console.WriteLine("Cut into 16 slices"); }
		public virtual void Box() { Console.WriteLine("Put into a rainbow box"); }
	}

	class StinkyTofuPizza : Pizza
	{
		public override void Bake()
		{
			Console.WriteLine("Bake for 10 minutes");
		}
	}

	class LoBaBunPizza : Pizza
	{
		public override void Cut()
		{
			Console.WriteLine("Cut into 3000 slices");
		}
	}
}
