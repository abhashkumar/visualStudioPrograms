public class MovieCity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Theatre> theatres { get; set; }
}

public class Theatre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Screen> screens { get; set; }
}

public class Screen
{
    public int Id { get; set; }
    public List<Show> shows { get; set; }   

}


public class Show
{
    public int Id { get; set; }
    public Movie movie { get; set; }
    public DateTime? startTime { get; set; }
    public DateTime? endTime { get; set; }
    public List<Seat> seats { get; set; }
}

public class Movie
{
    public int Id { get; set; }
    public int Title { get; set; }
    public string Description { get; set; }
}

public enum SeatType
{
    Gold,
    Siver,
    Platinum
}

public enum BookingStatus
{
    Free,
    Occupied,
    InPrgress
}

public class Seat
{
    public string Id { get; set; }
    public SeatType seatType;
    public BookingStatus bookingStatus;
    public double price;
    public Seat(SeatType seatType, BookingStatus bookingStatus, double price)
    {
        this.seatType = seatType;
        this.bookingStatus = bookingStatus;
        this.price = price;
    }
}

public class Booking
{
    public int Id { get; set; }
    public Show show { get; set; }
    public List<Seat> bookedSeats { get; set; }

}

public enum PaymentStatus
{
    Successful,
    Progress,
    Failed
}
public class Payment
{
    public Booking booking { get; set; }
    public Payment(Booking booking)
    {
        this.booking = booking;
    }
    public PaymentStatus  paymentStatus { get; set; }
    public void BillPay()
    {
        // calculate store log
    }
}

public class DriverController
{
    // Movie within a city
    public Dictionary<string, Movie> cityMovies = new Dictionary<string, Movie>();
    public List<MovieCity> cities = new List<MovieCity>();
    public readonly ReaderWriterLockSlim lockSlim = new ReaderWriterLockSlim();


    public void ShowListOfMoviesInACity()
    {
        foreach(var movie in cityMovies.Values)
        {
            Console.WriteLine(movie.Title);
        }
    }

    public void ShowShowsOfMovie(string city, Movie movie)
    {
        var movieCity = cities.Where(x => x.Name == city).FirstOrDefault();
        foreach(var theatre in movieCity.theatres)
        {
            var screens = theatre.screens;
            foreach(var screen in screens)
            {
                var shows = screen.shows;
                foreach(var show in shows)
                {
                    if (show.movie.Title == movie.Title)
                    {
                        Console.Write(show.startTime);
                    }
                }
            }
        }
    }

    public void GetSeatSOfAShow(Show show)
    {
        try
        {
            lockSlim.EnterReadLock();
            foreach (var seat in show.seats)
            {
                Console.WriteLine($"{seat.Id} - {seat.bookingStatus} - {seat.price}");
            }
        }
        finally
        {
            lockSlim.ExitReadLock();
        }
    }

    public void BookSeats(Show show, List<Seat> seats)
    {
        try
        {
            lockSlim.EnterWriteLock();
            foreach(var seat in seats)
            {
                if(seat.bookingStatus != BookingStatus.Free)
                {
                    Console.WriteLine("seats already booked try again");
                    return;
                }    
                seat.bookingStatus = BookingStatus.InPrgress;
            }
        }
        finally
        {
            lockSlim.ExitWriteLock();
        }
    }

    public void BillPay(Booking booking)
    {

        try
        {
            lockSlim.EnterWriteLock();
            var payment = new Payment(booking);
            try
            {
                payment.paymentStatus = PaymentStatus.Progress;

                payment.BillPay();


                payment.paymentStatus = PaymentStatus.Successful;
                foreach (var seat in booking.bookedSeats)
                {
                    if(seat.bookingStatus != BookingStatus.InPrgress)
                    {
                        throw new Exception("already booked");
                    }
                    seat.bookingStatus = BookingStatus.Occupied;
                }

                Console.WriteLine("Booking successful");
            }
            catch (Exception ex)
            {
                payment.paymentStatus = PaymentStatus.Failed;
                foreach (var seat in booking.bookedSeats)
                {
                    seat.bookingStatus = BookingStatus.Free;
                }
            }
        }
        finally
        {
            lockSlim.ExitWriteLock();
        }

    }
}

/*
 
 better to optimistic locking since most of the c# locs are pessimistic and optimistock is implement on database using version of data, below method can still be helpful, if one thread in side
critical seaction, other thread ill only wait for 1 sec before being timeout 

public void BookSeats(int[] seatsToBook)
{
    List<int> bookedSeats = new List<int>(); // Store booked seats temporarily

    // Lock individual seats being booked, with a timeout to prevent potential deadlocks
    foreach (var seat in seatsToBook)
    {
        bool lockAcquired = false;
        try
        {
            if (Monitor.TryEnter(lockObject, TimeSpan.FromSeconds(1))) // Try to acquire the lock with a timeout
            {
                lockAcquired = true;
                if (seats.ContainsKey(seat) && seats[seat])
                {
                    bookedSeats.Add(seat); // Add the seat to the list of booked seats
                    seats[seat] = false; // Mark the seat as booked
                }
                else
                {
                    Console.WriteLine($"Seat {seat} is not available.");
                    return; // Exit early if any seat is not available
                }
            }
            else
            {
                Console.WriteLine($"Timeout while attempting to book seat {seat}. Please try again later.");
                return; // Exit early if the lock couldn't be acquired
            }
        }
        finally
        {
            if (lockAcquired)
            {
                Monitor.Exit(lockObject); // Release the lock if acquired
            }
        }
    }

    // Print success message and booked seats outside of the lock
    Console.WriteLine($"Seats booked successfully: {string.Join(", ", bookedSeats)}");
}

 
 
 
 */



internal class Program
{
    private static void Main(string[] args)
    {
        
    }
}