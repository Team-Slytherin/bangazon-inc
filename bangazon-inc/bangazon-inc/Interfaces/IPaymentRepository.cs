using bangazon_inc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bangazon_inc.Interfaces
{
    public interface IPaymentRepository
    {
        Payment GetSinglePayment(int paymentId);
        IEnumerable<Payment> GetAllPayments();
        int EditPayment(Payment payment);
    }
}
