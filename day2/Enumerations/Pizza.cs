using System;

namespace Enumerations {
    public class Pizza {
        public PizzaSize Size { get; set; }
        public PizzaToppings Toppings { get; set; }

        public override string ToString() {
          return $"{Size} pizza ({Toppings} {(IsVegan ? " VG" : IsVegetarian ? " V" : "")})";
        }

        const PizzaToppings NON_VEGETARIAN = PizzaToppings.Ham | PizzaToppings.Pepperoni;
        const PizzaToppings NON_VEGAN = NON_VEGETARIAN | PizzaToppings.Cheese;

        public bool IsVegetarian {
          get {
            return ((NON_VEGETARIAN & Toppings) == 0);
          }
        }

        public bool IsVegan {
          get {
            return ((NON_VEGAN & Toppings) == 0);
          }
        }

        public decimal Price {
            get {
                switch(Size) {
                    case PizzaSize.Small: return 250.00M;
                    case PizzaSize.Medium: return 450.00M;
                    case PizzaSize.Large: return 650.00M;
                    default: return 850.00M;
                }
            }
        }
    }
}
