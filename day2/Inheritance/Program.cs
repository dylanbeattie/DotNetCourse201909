namespace Inheritance {
    class Program {
        static void Main(string[] args) {
            var fido = new Dog() { Name = "Fido" };
            var bryan = new Dolphin { Name = "Bryan" };
            var zoo = new Zoo();
            zoo.AddAnimal(fido);
            zoo.AddAnimal(bryan);
            zoo.AddAnimal(new Cricket() { Name = "Toby" });

            zoo.Tour();
        }
    }

    public class Cricket : Animal {

        public override int Legs => 6;

        public override string SayHello() {
            return "chirp-chirp!";
        }
    }
}
