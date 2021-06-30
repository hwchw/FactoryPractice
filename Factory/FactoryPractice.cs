using System;

namespace Factory
{
	class FactoryPractice
	{
		static void Main(string[] args)
		{
			var myPizza = OrderPizza("StinkyTofu");

			Console.ReadLine();
		}

		private static Pizza OrderPizza(string pizzaType)
		{
			//對修改開放，而這邊每次需要新增一種 Pizza 口味的時候，就會需要新增一個 if, 所以第一步先從這邊抽離
			Pizza pizza;
			if (pizzaType=="LoBaBun")
			{
				pizza = new LoBaBunPizza();
			}
			else if (pizzaType == "StinkyTofu")
			{
				pizza = new StinkyTofuPizza();
			}
			else
			{
				pizza = new Pizza();
			}

			pizza.Prepare();
			pizza.Bake();
			pizza.Cut();
			pizza.Box();
			return pizza;
		}
	}

	class Pizza
	{
		public void Prepare() { Console.WriteLine("Preparing"); }
		public void Bake() { Console.WriteLine("Baking"); }
		public void Cut() { Console.WriteLine("Cutting"); }
		public void Box() { Console.WriteLine("Boxing"); }
	}

	class StinkyTofuPizza : Pizza
	{
	}

	class LoBaBunPizza : Pizza
	{
	}
}
