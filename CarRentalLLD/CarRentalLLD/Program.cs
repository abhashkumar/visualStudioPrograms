

// https://gitlab.com/shrayansh8/interviewcodingpractise/-/tree/main/src/LowLevelDesign/LLDCarRentalSystem
// https://www.udemy.com/course/system_design_lld_hld/learn/lecture/41933082#overview


/* Enum VehicleType: CAR, BIKE
 * Enum RunningStatusOfVahicle: ACTIVE INACTIVE
 * Class Vahicle: Base class
 * Class Car
 * Class Bike
 * class Users
 * class Store: has VahicleInventoryManagement
 * class Location
 * class Reservation: Has User, Has Vahicle, ReservationStatus, ReservationType, StartTime, EndTime 
 * Enum ReservationStatus: SCHEDULED, INPROGRESS, CLOSED
 * Enum ReservationType: Hourly, Daily
 * Class Bill: Generatated Against a reservation, isPaid
 * class Payment: method PayBill
 * class PaymentDetails: against a bill, amountPaid, PaymentMode
 * Enum PaymentMode: CASH, ONLINE
 * Enum PaymentStatus: SUCCESS, FILED, PROCRESS
 * class VahicleInventoyManagement: Base class, List of Reservations(it can be inside store also)
 * class CarInventoryManagement
 * class BikeInventoryManagement
 * class RentalSystem 
 * 
 * You can also check if a bike is available for reservation for a specific persiod by quering the reservaion list
 */


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}