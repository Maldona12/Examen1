namespace Examen1
{

  class Menu{

    Ruleta ruleta = new Ruleta();
    public bool ShowMenu(){
      if(ruleta.monto == 0){
          Console.WriteLine("Perdiste");
          ruleta.Balance();
          return false;
        }
      Console.WriteLine("Selecciona una opcion:");
      Console.WriteLine("1.- Apostar");
      Console.WriteLine("2.- Historial de giros");
      Console.WriteLine("3.- Estadisticas");
      Console.WriteLine("4.- Retirarse");
      Console.Write("Opción: ");

      switch(Console.ReadLine()){
        case "1":
          ruleta.Apostar();
          return true;
        case "2":
          ruleta.Historial();
          return true;
        case "3":
          ruleta.Estadistica();
          return true;
        case "4":
          ruleta.Balance();
          return false;
            default:
          return true;
        }
    }
  }
}