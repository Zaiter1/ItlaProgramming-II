
using P2_Tarea_MapaDeClases.Entities;


// PRUEBA 

var obj1 = new Student();
obj1.Id = 1;
obj1.Name = "Miguel";
obj1.Age = 19;
obj1.Major = "Software Development";
obj1.EnrollmentDate = DateTime.Parse("2025-01-13");

Console.WriteLine(obj1.Name);
Console.WriteLine(
    $" ESTDIANTE: Name: {obj1.Name}, Age: {obj1.Age}, Major: {obj1.Major}, inscripcion : ´{obj1.EnrollmentDate}"
);





var obj2 = new Employee(); 
obj2.Id = 1;
obj2.Name = "Raul";
obj2.Age = 42;
obj2.Salary = 28000;

Console.WriteLine(
    $"EMPLEADO : Name: {obj2.Name}, Age: {obj2.Age}, Salary: {obj2.Salary} , "
);

