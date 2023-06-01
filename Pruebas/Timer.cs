using System;
using System.Timers;
using System.Threading.Tasks;

public class Timer

{
    private static System.Timers.Timer aTimer;

    public static void Main()
    {
        SetTimer();

        Console.WriteLine("\nPress the Enter key to exit the application...\n");
        Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
        Console.ReadLine();
        aTimer.Stop();
        aTimer.Dispose();

        Console.WriteLine("Terminating the application...");
    }

    private static void SetTimer()
    {
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(2000);
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }

    //Que pase a las 12:00 am
    //que hayan pasado mas de 12 horas
    //guardar el tiempo en el que pasa


    static DateTime fechaUltimoCrawler;
    static DateTime fechaUltimoCrawlerGuardada = new DateTime(2023, 5, 31, 0, 50, 52);
    static Boolean crawlerProcesando = false;
    static int HorasDeMargen = 23;

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        DateTime ahora = DateTime.Now;

        Console.WriteLine("Última fecha en la que se procesó el crawler: " + fechaUltimoCrawlerGuardada);
        Console.WriteLine("Crawler procesando: " + crawlerProcesando);
        Console.WriteLine("Diferencia de horas: " + (ahora - fechaUltimoCrawlerGuardada).TotalHours);

        //Simulacion de crawler
        //Que procese si: 

        // - El crawler no esta procesando
        // - la diferencia entre ultima hora que se proceso el crawler y la hora de ahora es mayor a 23 

        if (!crawlerProcesando && (ahora - fechaUltimoCrawlerGuardada).TotalHours > HorasDeMargen)
        {
            crawlerProcesando = true;
            Task t = Task.Run(async () =>
        {
            CancellationTokenSource source = new CancellationTokenSource();
            await Task.Delay(TimeSpan.FromSeconds(7));
            fechaUltimoCrawler = DateTime.Now;
            Console.WriteLine("Simulacion de crawler acaba a las: " + fechaUltimoCrawler);
            crawlerProcesando = false;
        });

            t.Wait();
        }

    }



}
