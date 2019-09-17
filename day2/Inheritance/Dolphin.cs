namespace Inheritance {
    public class Dolphin : Animal {
        public override string SayHello() {
            return "Click click meep fweeep!";
        }
        public override int Legs {
            get { return 0; }
        }
    }    
}
