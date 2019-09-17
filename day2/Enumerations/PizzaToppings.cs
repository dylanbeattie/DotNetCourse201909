using System;

namespace Enumerations {
    [Flags]
    public enum PizzaToppings : byte {
        Cheese    = 0b00000001,
        Tomato    = 0b00000010,
        Olives    = 0b00000100,
        Pepperoni = 0b00001000,
        Ham       = 0b00010000,
        Mushroom  = 0b00100000,
        Capers    = 0b01000000,
        Pineapple = 0b10000000
    }
}
