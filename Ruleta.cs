namespace Examen1
{
    class Ruleta{
        Rueda rueda;
        public int? monto = 300;
        public int? apuesta = 0;
        public int numMasRepetido=0;
        public int numMenosRepetido=0;
        public List<Rueda> listaGiros;
        public Ruleta() {
            listaGiros = new List<Rueda>();
        } 
        public int? getMonto(){
            return monto;
        }  
        public void Apostar(){
            Console.WriteLine($"Saldo actual: {monto}");
            Console.WriteLine("Cuanto deseas Apostar? (Solo multiplos de 10)");
            string? Cadena = Console.ReadLine();
            apuesta = Cadena != null ? int.Parse(Cadena) : 0;
            Console.Clear();
            if ((apuesta % 10 == 0) == false) {
                Console.WriteLine("No puedes apostar esta cantidad");
            }else{
                if(apuesta>monto){
                    Console.WriteLine("Tu saldo es insuficiente");
                }else{
                    Console.WriteLine("Como deseas Apostar?");  
                    Console.WriteLine("1.- Numero especifico de la ruleta");                  
                    Console.WriteLine("2.- Color de la casilla");
                    Console.WriteLine("3.- El numero de la casilla es Par o Impar");
                    Console.Write("Opción: ");
                    string? Cadena1 = Console.ReadLine();
                    int op = Cadena1 != null ? int.Parse(Cadena1) : 0;
                    
                    rueda = new Rueda(); // Se crea una nueva instancia de Rueda

                    if(op==1){
                        Console.Write("Ingresa el número en el que deseas apostar: ");
                        string? Cadena2 = Console.ReadLine();
                        int num = Cadena2 != null ? int.Parse(Cadena2) : 0;
                        if(num == rueda.numero){
                            Console.WriteLine($"¡Ganaste! El número de la rueda es {rueda.numero}");
                            monto = apuesta*10;
                        }else{
                            Console.WriteLine($"Perdiste. El número de la rueda es {rueda.numero}");
                            monto = monto-apuesta;
                        }
                        AgregarGiro(rueda);
                    }
                    if(op==2){
                        Console.WriteLine("Ingresa el color en el que deseas apostar (Rojo o Negro): ");
                        string? c = Console.ReadLine();
                        if(c == rueda.determinarColor()){
                            Console.WriteLine($"¡Ganaste! La casilla es {rueda.determinarColor()}");
                            monto = apuesta*5;
                        }else{
                            Console.WriteLine($"Perdiste. La casilla es {rueda.determinarColor()}");
                            monto = monto-apuesta;
                        }
                        AgregarGiro(rueda);
                    }
                    if(op==3){
                        Console.WriteLine("Ingresa el tipo de paridad en el que deseas apostar (Par o Impar): ");
                        string? p = Console.ReadLine();
                        if(p == rueda.determinarParidad()){
                            Console.WriteLine($"¡Ganaste! La casilla es {rueda.determinarParidad()}");
                            monto = apuesta*2;
                        }else{
                            Console.WriteLine($"Perdiste. La casilla es {rueda.determinarParidad()}");
                        monto = monto-apuesta;
                        }
                        AgregarGiro(rueda);

                    }
                }
            }
        }
        
        public void Historial(){
            Console.WriteLine("Historial de Giros:");
            foreach(Rueda item in listaGiros){
                Console.WriteLine(item.ToString());
            } 
        }

        public void Estadistica(){
            Balance();
            Giros();
            Numeros();

        }
        public void AgregarGiro(Rueda giro){
                listaGiros.Add(giro);
        }
        public void MostrarGiros(){
            foreach(Rueda item in listaGiros){
                Console.WriteLine(item.ToString());
            } 
        }
        public void Balance(){
            //No terminada
            Console.WriteLine($"Tu saldo actual es: {monto}");
            int? ganancias = 0;
            int? perdidas = 0;

            foreach(Rueda item in listaGiros){
                int? gananciaGiro = 0;
                int? perdidaGiro = 0;
                if(item.numero == rueda.numero){
                    gananciaGiro = apuesta*10;
                }else if(item.determinarColor() == rueda.determinarColor()){
                    gananciaGiro = apuesta*5;
                }else if(item.determinarParidad() == rueda.determinarParidad()){
                    gananciaGiro = apuesta*2;
                }else{
                    perdidaGiro = apuesta;
                }
                ganancias += gananciaGiro;
                perdidas += perdidaGiro;
            }

            Console.WriteLine($"Ganancias: {ganancias}");
            Console.WriteLine($"Perdidas: {perdidas}");
            Console.WriteLine($"Saldo final: {monto+ganancias-perdidas}");
        }
        public void Giros(){
            int cantidadElementos = listaGiros.Count;
            Console.WriteLine($"Giros Realizados: {cantidadElementos} ");
        }
        public void Numeros(){
             Dictionary<int, int> repeticiones = new Dictionary<int, int>();
            // Contar cuántas veces ha salido cada número
            foreach (Rueda rueda in listaGiros) {
                if (repeticiones.ContainsKey(rueda.numero)) {
                    repeticiones[rueda.numero]++;
                } else {
                    repeticiones[rueda.numero] = 1;
                }
            }
            // Encontrar el número más repetido y el menos repetido
            int maxRepeticiones = 0;
            int minRepeticiones = int.MaxValue;
            foreach (KeyValuePair<int, int> kvp in repeticiones) {
                if (kvp.Value > maxRepeticiones) {
                    maxRepeticiones = kvp.Value;
                    numMasRepetido = kvp.Key;
                }
                if (kvp.Value < minRepeticiones) {
                    minRepeticiones = kvp.Value;
                    numMenosRepetido = kvp.Key;
                }
            }
            Console.WriteLine($"Número más repetido: {numMasRepetido} (se repitió {maxRepeticiones} veces)");
            Console.WriteLine($"Número menos repetido: {numMenosRepetido} (se repitió {minRepeticiones} veces)");
        }
    }
}