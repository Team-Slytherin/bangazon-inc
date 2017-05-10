using bangazon_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bangazon_inc.Interfaces
{
    interface IPaymentRepository
    {
        Payment getSinglePayment(int paymentId);
        IEnumerable<Payment> GetAllPayments();
        int editPayment(Payment payment);
    }
}
