using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bangazon_inc.Interfaces;
using bangazon_inc.Models;
using System.Data.Entity;

namespace bangazon_inc.DAL
{
    public class PaymentRepository : IPaymentRepository
    {

        private readonly AppContext _appContext;
        public PaymentRepository(AppContext appContext)
        {
            _appContext = appContext;
        }

        public int editPayment(Payment payment)
        {
            var updatedPayment = _appContext.Entry(payment);
            updatedPayment.State = EntityState.Modified;
            return _appContext.SaveChanges();
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _appContext.Payments;
        }

        public Payment getSinglePayment(int paymentId)
        {
            return _appContext.Payments.Find(paymentId);
        }
    }
}
