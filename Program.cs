namespace mat_modeling_lab_2
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Моделирование отражения света методом градиентного спуска");

            // Расстояние между источником и приёмником
            int n = 10;

            // Высота приёмника и источника
            int h = 5;

            // Координаты источника света
            Point source = new Point(0, h);

            // Координаты отражателя
            Point reflector = new Point(0, 0);

            // Координаты приемника света
            Point receiver = new Point(n, h);

            // Создаем массив углов падения
            double[] incidentSteps = GenerateIncidentStep(n);

            // Вычисляем и выводим длины отраженных лучей
            Console.WriteLine("\nШаг от источника до отражателя (градусы)  |  Длина отраженного луча                            ");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            foreach (var incidentStep in incidentSteps)
            {
                //double reflectedAngle = GradientDescent(source, reflector, receiver, incidentAngle);
                double length = CalculateLength(source, reflector, receiver, incidentStep);
                Console.WriteLine($"{incidentStep,40:F2}  |  {length,50:F2} |");
            }
        }

        static double[] GenerateIncidentStep(int n)
        {
            // Генерируем массив углов падения от 0 до 90 градусов с шагом 5 градусов
            double[] steps = new double[n + 1];
            for (int i = 0; i <= n; i++)
            {
                steps[i] = i;
            }
            return steps;
        }

        /*static double GradientDescent(Point source, Point reflector, Point receiver, double incidentAngle)
        {
            // Инициализация угла отражения для градиентного спуска
            double reflectedAngle = 0.0;

            // Коэффициент скорости обучения
            double learningRate = 0.01;

            // Количество итераций градиентного спуска
            int iterations = 1000;

            for (int i = 0; i < iterations; i++)
            {
                double gradient = CalculateGradient(source, reflector, receiver, incidentAngle, reflectedAngle);
                reflectedAngle -= learningRate * gradient;
            }

            return reflectedAngle;
        }*/

        /*static double CalculateGradient(Point source, Point reflector, Point receiver, double incidentAngle, double reflectedAngle)
        {
            // Расчет градиента длины отраженного луча по отраженному углу
            double epsilon = 1e-6;
            double gradient = (CalculateLength(source, reflector, receiver, incidentAngle, reflectedAngle + epsilon) -
                               CalculateLength(source, reflector, receiver, incidentAngle, reflectedAngle)) / epsilon;

            return gradient;
        }*/

        static double CalculateLength(Point source, Point reflector, Point receiver, double incidentStep)
        {
            // Расчет длины отраженного луча
            double a1 = CalculateDistance(source, new Point(reflector.X, reflector.Y + incidentStep));
            double b1 = CalculateDistance(new Point(reflector.X, reflector.Y + incidentStep), receiver);
            //double a2 = a1 / Math.Cos(incidentAngle);
            //double b2 = b1 / Math.Cos(reflectedAngle);
            return a1 + b1;
        }

        static double CalculateDistance(Point p1, Point p2)
        {
            // Расчет расстояния между двумя точками
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
    }
}

class Point
{
    public double X { get; }
    public double Y { get; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}
