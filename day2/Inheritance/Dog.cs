namespace Inheritance {
    public class Dog : Animal {

        // public override string ToString() {
        //     return $"I'm {Name} - I'm a GOOD DOG!";
        // }

        public override int Legs {
            get { return 4; }
        }
        public override string SayHello() {
            return "Woof!";
        }
    }
}
