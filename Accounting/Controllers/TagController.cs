﻿using Accounting.Business;
using Accounting.CustomAttributes;
using Accounting.Models.TagViewModels;
using Accounting.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Controllers
{
  [AuthorizeWithOrganizationId]
  [Route("tag")]
  public class TagController : BaseController
  {
    private readonly TagService _tagService;
    private readonly string _databaseName;

    public TagController(RequestContext requestContext, TagService tagService)
    {
      _databaseName = requestContext.DatabaseName;
      _tagService = tagService;
    }

    [HttpGet]
    [Route("tags")]
    public async Task<IActionResult> Tags()
    {
      TagsViewModel tagsViewModel = new TagsViewModel();

      List<Tag> tags = await _tagService.GetAllAsync();

      tagsViewModel.Tags = tags.Select(tag => new TagViewModel
      {
        ID = tag.TagID,
        Name = tag.Name
      }).ToList();

      return View(tagsViewModel);
    }
  }
}