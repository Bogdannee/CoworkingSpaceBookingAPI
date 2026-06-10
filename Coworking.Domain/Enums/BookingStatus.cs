using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Domain.Enums
{
    public enum BookingStatus
    {
        Created = 1,   // Бронь создана
        Confirmed = 2, // Подтверждена/Оплачена
        Canceled = 3,  // Отменена пользователем или системой
        Completed = 4  // Время брони вышло
    }
}
