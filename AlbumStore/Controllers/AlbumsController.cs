using AlbumStore.Data;
using AlbumStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace AlbumStore.Controllers;

[ApiController]
[Route("monkeyface/[controller]")]
public class AlbumsController : ControllerBase
{
    private readonly AlbumDbContext _context;

    public AlbumsController(AlbumDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Albums.ToListAsync());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetOne(int id)
    {
        var album = await _context.Albums.FindAsync(id);
        if (album == null)
        {
            return NotFound();
        }

        return Ok(album);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> CreateAlbum(Album album)
    {
        _context.Albums.Add(album);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetOne), new {id = album.Id}, album);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAlbum(Album album)
    {
        // var a = await _context.Albums.FindAsync(album.Id);
        // if (a == null)
        // {
        //     return NotFound();
        // }

        // a.Name = album.Name;

        _context.Entry(album).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(album);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlbum(int id)
    {
        var album = await _context.Albums.FindAsync(id);
        if (album == null)
        {
            return NotFound();
        }
        
        _context.Albums.Remove(album);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}