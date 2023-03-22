namespace Examen1
{
    class Rueda {
        public Random random = new Random();
        public int numero;
        public string color;
        public string paridad;
        List<int> numerosRojo = new List<int> {2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35};
        List<int> numerosNegro = new List<int> {1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36};

        public Rueda() {
            this.numero = random.Next(0, 37); // Genera un número aleatorio entre 0 y 36
            this.color = determinarColor();
            this.paridad = determinarParidad();
        }
        public override string ToString() {
            return $"Numero: {numero}, Color: {color}, Paridad: {paridad}";
        }

        public string determinarColor(){

            if (numero == 0) {
                return "Sin color";
            }
            if (numerosRojo.Contains(numero)) {
                return "Rojo";
            }
            if (numerosNegro.Contains(numero)) {
                return "Negro";
            }
            // si el número no es ni rojo ni negro, entonces no tiene color asignado
            return "Sin color asignado";
        }

        public string determinarParidad() {
            if (numero % 2 == 0) {
                return "Par";
            } else {
                return "Impar";
            }
        }
    }
}