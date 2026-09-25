using Microsoft.AspNetCore.Mvc;
using Zdybanka.Application.Services;

namespace Zdybanka.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagController : Controller
{
    private readonly TagService _tagService;

    public TagController(TagService tagService)
    {
        _tagService = tagService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return Ok(await _tagService.GetTagsAsync());
    }
}