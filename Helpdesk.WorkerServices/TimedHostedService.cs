using System.ComponentModel;
using Helpdesk.Core.Dtos;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Helpdesk.WorkerServices
{

    public class TimedHostedService : IHostedService, IDisposable
    {
        private BackgroundWorker _backgroundWorker;

        private IUnitOfWorkBl _unitOfWorkBl;
        private int executionCount = 0;
        private readonly ILogger<TimedHostedService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private Timer _timer = null;

        public TimedHostedService(
            ILogger<TimedHostedService> logger
            //, IUnitOfWorkBl unitOfWorkBl
            , IServiceScopeFactory scopeFactory
        )
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += DoWork;
            _backgroundWorker.RunWorkerCompleted += RunWorkerCompleted;
            _backgroundWorker.ProgressChanged += ProgressChanged;
            _backgroundWorker.WorkerSupportsCancellation = true;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            // for (int i = 0; i < 100; i++)
            // {
            //     Thread.Sleep(1000);
            //     _backgroundWorker.ReportProgress(i);

            //Check if there is a request to cancel the process
            if (_backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                _backgroundWorker.ReportProgress(0);
                return;
            }
            ResponsiveDto item;

            item = e.Argument as ResponsiveDto;
            _unitOfWorkBl.Responsive.SendResponsive(item.DocumentId);

            e.Result = item;
            // }
            // //If the process exits the loop, ensure that progress is set to 100%
            // //Remember in the loop we set i < 100 so in theory the process will complete at 99%
            // _backgroundWorker.ReportProgress(100);
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // e.ProgressPercentage;
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //"Process was cancelled";
            }
            else if (e.Error != null)
            {
                //"There was an error running the process. The thread aborted";

            }
            else
            {
                //"Process was completed";
                ResponsiveDto item;

                item = e.Result as ResponsiveDto;
                _unitOfWorkBl.Responsive.UpdateDateSend(item.Id);
                DoWork(null);
            }
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(3));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);

            if (_backgroundWorker.IsBusy == false)
            {
                ProcessSendMail();
            }
        }

        private void ProcessSendMail()
        {
            try
            {

                _unitOfWorkBl = _scopeFactory.CreateAsyncScope().ServiceProvider.GetRequiredService<IUnitOfWorkBl>();
                //Condición: hay correos donde la fecha de envio es nula
                bool existsWithoutSend = _unitOfWorkBl.Responsive.ExistsWithoutSendAsync().Result;
                if (existsWithoutSend)
                {
                    //  Si
                    //      Obtener el correos para enviar
                    ResponsiveDto item;

                    item = _unitOfWorkBl.Responsive.GetWithoutSendAsync().Result;
                    //      Enviar los correos
                    _backgroundWorker.RunWorkerAsync(item);
                }
                else
                {
                    //  No
                    //      Pues nada
                }
            }
            catch (Exception)
            {

            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);
            _backgroundWorker.CancelAsync();

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }


    }//end class
}