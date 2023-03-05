public class Item : WorldEntity
{
    protected string _name;

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        this._name = name;
    }

}
