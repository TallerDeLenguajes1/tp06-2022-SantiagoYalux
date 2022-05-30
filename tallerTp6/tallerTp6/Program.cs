// See https://aka.ms/new-console-template for more information
/*
#region Ejercicio 1
class Calculadora
{
    private double resultado;
    private double valor;
    public Calculadora()
    {
        //Inicializamos el resultado y la calculadora
        resultado = 0;
        IniciarCalculadora();
    }

    private void IniciarCalculadora()
    {
        ConsoleKeyInfo op;
        Menu miMenu = new Menu();
        miMenu.DibujarMenu();
        op = Console.ReadKey();

        do
        {
            miMenu.DibujarMenu();
            op = Console.ReadKey();

            switch (op.Key)
            {
                case ConsoleKey.A:
                    //Opción de sumar
                    Console.Clear();

                    resultado = Sumar(resultado);
                    MostrarResultado();

                    Console.ReadKey();
                    break;

                case ConsoleKey.B:
                    //Opción de restar
                    Console.Clear();

                    resultado = Restar(resultado);
                    MostrarResultado();

                    Console.ReadKey();
                    break;

                case ConsoleKey.C:
                    //Opción de multiplicar
                    Console.Clear();

                    resultado = Multiplicar(resultado);
                    MostrarResultado();

                    Console.ReadKey();
                    break;

                case ConsoleKey.D:
                    //Opción de dividir
                    Console.Clear();

                    resultado = Dividir(resultado);
                    MostrarResultado();

                    Console.ReadKey();
                    break;
                case ConsoleKey.E:
                    //Opción limpiar calculadora
                    Console.Clear();
                    Limpiar();

                    Console.ReadKey();
                    break;

            }
        } while (op.Key != ConsoleKey.H);
    }

    private double Sumar(double termino)
    {
        Console.WriteLine("Ingresa el numero");
        valor = float.Parse(Console.ReadLine());

        return termino + valor;
    }

    private double Restar(double termino)
    {
        Console.WriteLine("Ingresa el numero");
        valor = float.Parse(Console.ReadLine());
        return termino - valor;
    }

    private double Multiplicar(double termino)
    {
        Console.WriteLine("Ingresa el numero");
        valor = float.Parse(Console.ReadLine());
        return termino * valor;
    }

    private double Dividir(double termino)
    {
        Console.WriteLine("Ingresa el numero");
        valor = float.Parse(Console.ReadLine());
        return termino / valor;
    }

    private void Limpiar()
    {
        resultado = 0;
        Console.WriteLine("Borrado");
    }
    private void MostrarResultado()
    {
        Console.WriteLine($"Resultado = {resultado}");
    }
}
class Menu
{
    #region Metodos
    public void DibujarMenu()
    {
        Console.Clear();

        Console.WriteLine("*************************");
        Console.WriteLine("A- Sumar\n");
        Console.WriteLine("B- Restar\n");
        Console.WriteLine("C- Multiplicar\n");
        Console.WriteLine("D- Dividir\n");
        Console.WriteLine("E- Limpiar\n");
        Console.WriteLine("F- Salir\n");
        Console.WriteLine("*************************");

    }
    #endregion
}
#endregion
*/
#region Ejercicio 2

Iniciar();

void Iniciar()
{
    //Apartado C
    List<Empleado> ListaEmpleados = new List<Empleado>();

    for (int i = 1; i <= 3; i++)
    {
        Empleado empleado = new Empleado();
     

        ListaEmpleados.Add(empleado);
    }

    //Apartado D
    double TotalSalarios = 0;
    foreach (Empleado empleado in ListaEmpleados)
    {
        TotalSalarios += empleado.CalcularSalario();
        Console.WriteLine($"Total paga de salarios = {TotalSalarios}");
    }

    //Apartado e
    Empleado EmpProximoJubilarse = new Empleado();
    EmpProximoJubilarse = ListaEmpleados[0];
    foreach (Empleado empleado in ListaEmpleados)
    {
        if(empleado.CalcularFaltanteJubilacion() < EmpProximoJubilarse.CalcularFaltanteJubilacion())
        {
            EmpProximoJubilarse = empleado;
        }
    }
    Console.WriteLine("---Empleado Proximo a jubilarse---");
    EmpProximoJubilarse.MostrarDatosEmpleado();
    Console.WriteLine("----------------------------------");
}
public enum cargos
{
    Auxiliar = 1,
    Administrativo = 2,
    Ingeniero = 3,
    Especialista = 4,
    Investigador = 5
}

public class Empleado
{
    private string Nombre;
    private string Apellido;
    private DateTime FechaNacimiento;
    private char EstadoCivil;
    private char Genero;
    private DateTime FechaIngreso;
    private double SueldoBasico;
    private cargos Cargo;

    public void CargarDatos()
    {
        int cargo = 0;
        Console.WriteLine("Ingrese el nombre del empleado");
        Nombre = Console.ReadLine();
        Console.WriteLine("Ingrese el apellido del empleado");
        Apellido = Console.ReadLine();
        Console.WriteLine("Ingrese la fecha de nacimiento del empleado formato ej. 24/10/2002");
        FechaNacimiento = Convert.ToDateTime(Console.ReadLine());
        Console.WriteLine("Ingrese el estado civil C-casado, S-soltero");
        EstadoCivil = Console.ReadLine()[0];
        Console.WriteLine("Ingrese la fecha de ingreso del empleado formato ej. 24/10/2002");
        FechaIngreso = Convert.ToDateTime(Console.ReadLine());
        Console.WriteLine("Ingresa el sueldo básico del empleado");
        SueldoBasico = double.Parse(Console.ReadLine());

        Console.WriteLine("Ingresa Cargo: 1-Auxiliar, 2-Administrativo, 3-Ingeniero, 4-Especialista, 5-Investigador");
        cargo = int.Parse(Console.ReadLine());
        switch (cargo)
        {
            case 1:
                Cargo = cargos.Auxiliar;
                break;

            case 2:
                Cargo = cargos.Administrativo;
                break;

            case 3:
                Cargo = cargos.Ingeniero;
                break;

            case 4:
                Cargo = cargos.Especialista;
                break;

            case 5:
                Cargo = cargos.Investigador;
                break;
        }
    }
    public void AntiguedadEmpleado()
    {
        Console.WriteLine($"El empleado esta hace {(DateTime.Now - FechaIngreso).ToString(@"dd\d\ hh\h\ mm\m\ ")} dias horas y minutos");
    }
    public void CalcularEdad()
    {
        TimeSpan EdadEmpleado = (DateTime.Now - FechaNacimiento);

        Console.WriteLine($"El empleado tiene {(int)(EdadEmpleado.TotalDays / 365)} años");
    }
    public int CalcularFaltanteJubilacion()
    {
        int AñosFaltanteJubilacion = (int)(((DateTime.Now - FechaNacimiento).TotalDays) / 365);


        if (Genero == 'M')
            Console.WriteLine($"Al empleado le faltan {65 - AñosFaltanteJubilacion} años para jubilarse");
        else
            Console.WriteLine($"Al empleado le faltan {60 - AñosFaltanteJubilacion} años para jubilarse");

        return AñosFaltanteJubilacion;
    }
    public double CalcularSalario()
    {
        double Adicional = 0;
        int Antiguedad = (int)(((DateTime.Now - FechaIngreso).TotalDays) / 365);

        if (Antiguedad < 20 && Antiguedad > 0)
            Adicional = SueldoBasico * Antiguedad / 10;
        else if (Antiguedad > 20)
            Adicional = SueldoBasico * 0.25;

        if (Cargo == cargos.Especialista || Cargo == cargos.Ingeniero)
            Adicional = Adicional + Adicional * 0.50;

        if (EstadoCivil == 'c')
            Adicional = Adicional + 15000;

        Console.WriteLine($"El salario del empleado {Nombre} {Apellido} es {SueldoBasico + Adicional}");
        return SueldoBasico + Adicional;
    }
    public void MostrarDatosEmpleado() 
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Apellido: {Apellido}");
        Console.WriteLine($"Fecha Nacimiento: {FechaNacimiento}");
        Console.WriteLine($"Estado Civil: {EstadoCivil}");
        Console.WriteLine($"Genero: {Genero}");
        Console.WriteLine($"FechaIngreso: {FechaIngreso}");
        Console.WriteLine($"SueldoBasico: {SueldoBasico}");
        Console.WriteLine($"Cargo: {Cargo}");

        AntiguedadEmpleado();
        CalcularEdad();
        CalcularFaltanteJubilacion();
        CalcularSalario();
    }
}

#endregion


