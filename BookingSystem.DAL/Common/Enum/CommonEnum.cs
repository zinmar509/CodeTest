using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Common.Enum
{
    public enum RoomStatus
    {
        Occupied,
        Available,
        Reserved,
        Dirty,
        Repair,
        UnderMaintenance,
        CheckedOut
    }

    public enum RoomType
    {
        SingleRoom,
        DoubleRoom,
        TwinRoom,
        DeluxeRoom,
        FamilyRoom,
        Suite,
        Studio,
        Presidential,
        ConnectingRooms
    }

    public enum BookingStatus
    {
        Pending,
        Confirmed,
        CheckedIn,
        CheckedOut,
        Cancelled,
        NoShow,
        Studio,
        Presidential,
        ConnectingRooms
    }

    public enum PaymentStatus
    {
        UnPaid,
        Paid,
        PartialPaid
    }

    public enum Status
    {
        Active,
        InActive
    }
}
