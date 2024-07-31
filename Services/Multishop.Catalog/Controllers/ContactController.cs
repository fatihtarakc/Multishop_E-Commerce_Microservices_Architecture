using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.ContactDtos;
using Multishop.Catalog.Services.Abstract;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet("Contacts")]
        public async Task<IActionResult> Contacts()
        {
            var contactDtos = await contactService.GetAllAsync();
            if (contactDtos is null) return NotFound("In system, contact has not been yet !");

            return Ok(contactDtos);
        }

        [HttpGet("ContactsGetBy/{isRead}")]
        public async Task<IActionResult> ContactsGetBy(bool isRead)
        {
            var contactDtos = await contactService.GetAllWhereAsync(contact => contact.IsRead == isRead);
            if (contactDtos is null) return NotFound($"In system, contact which is {isRead} has not been yet !");

            return Ok(contactDtos);
        }

        [HttpGet("GetBy/{contactId}")]
        public async Task<IActionResult> GetBy(string contactId)
        {
            var contactDto = await contactService.GetFirstOrDefaultAsync(contact => contact.Id == contactId);
            if (contactDto is null) return NotFound();

            return Ok(contactDto);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ContactAddDto contactAddDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await contactService.AddAsync(contactAddDto);
            return Ok($"{contactAddDto.Subject} was added successfuly !");
        }

        [Authorize]
        [HttpDelete("Delete/{contactId}")]
        public async Task<IActionResult> Delete(string contactId)
        {
            if (string.IsNullOrWhiteSpace(contactId)) return BadRequest("Missing or incorrect entry !");

            await contactService.DeleteAsync(contactId);
            return Ok("This contact was deleted successfully !");
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(ContactUpdateDto contactUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await contactService.UpdateAsync(contactUpdateDto);
            return Ok("Contact was updated successfully !");
        }

        [Authorize]
        [HttpPut("Update/{contactId},{isRead}")]
        public async Task<IActionResult> Update(string contactId, bool isRead)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await contactService.UpdateAsync(contactId, isRead);
            return Ok("Contact was updated successfully !");
        }
    }
}