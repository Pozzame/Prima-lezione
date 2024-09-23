class Program
{
    public static void Main()
    {
        Model db = new Model();
        View view= new View(db);
        Controller controller = new Controller(db, view);

        controller.Menu();
    }       
}

