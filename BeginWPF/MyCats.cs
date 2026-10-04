namespace BeginWPF;

class MyCats
{
    public string _name { get; set; } = null!;
    public short _age { get; set; }
    public string _color { get; set; } = null!;
    public string _statʹ { get; set; } = null!;

    public MyCats()
    {
        _name = "Ім'я не вказано";
        _age = 0;
        _color = "Колір не вказано";
        _statʹ = "Стать не вказано";
    }
    public MyCats(string name, short age, string color, string statʹ)
    {
        _name = name;
        _age = age;
        _color = color;
        _statʹ = statʹ;
    }

    public override string ToString()
    {
        return $"{_name}, вік: {_age}, колір: {_color}, стать: {_statʹ}";
    }
}
