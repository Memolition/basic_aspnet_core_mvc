using Microsoft.AspNetCore.Mvc;

public class Greeting{
    public string Username;
}

public class HomeController : Controller {
    [Route("home/index/{username?}")]
    public IActionResult Index(string username = "user") {
        return View(new Greeting{ Username = username});
    }
}