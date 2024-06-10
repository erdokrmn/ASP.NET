using Microsoft.AspNetCore.Mvc;
using BitirmeProjesi.TcpServer;


namespace BitirmeProjesi.Controllers
{
    public class TcpServerController : Controller
    {
        private readonly BitirmeProjesi.TcpServer.TcpServer _tcpServer;

        public TcpServerController(BitirmeProjesi.TcpServer.TcpServer tcpServer)
        {
            _tcpServer = tcpServer;
        }

    

       
        public IActionResult TcpServerData()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StartTcpServer()
        {
            await _tcpServer.StartAsync();
            return RedirectToAction("Index");
        }
    }
}
