namespace Examen1
{
  class Program{
    static void Main(string[] args){
      Menu menu = new Menu();
      bool mostrarMenu = true;
      while(mostrarMenu){
      mostrarMenu = menu.ShowMenu();
      }
      // Rueda rueda = new Rueda();
      // Console.WriteLine(rueda.ToString());

    }
  }
}
