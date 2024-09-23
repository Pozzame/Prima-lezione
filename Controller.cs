class Controller
{
    private Model db;
    private View view;

    public Controller(Model db, View view){
        this.db = db;
        this.view = view;
    }
}