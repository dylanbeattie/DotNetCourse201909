namespace Inheritance {

    public abstract class Animal {

        public override string ToString() {
            return($"I'm {Name} - I'm a good {this.GetType().Name.ToLower()}");
        }

        public string Name { get; set; }

        public abstract int Legs { get; }

        public abstract string SayHello();

        public bool IsPet { 
            get {
                return true; 
            }
        }
    }
}
