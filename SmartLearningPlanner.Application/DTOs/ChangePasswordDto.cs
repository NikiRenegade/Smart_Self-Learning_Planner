using System;

namespace SmartLearningPlanner.Application.DTOs;

public class ChangePasswordDto
{ 
  public string Id { get; set; }
  public string CurrentPassword { get; set; }
  public string NewPassword { get; set; }
}
