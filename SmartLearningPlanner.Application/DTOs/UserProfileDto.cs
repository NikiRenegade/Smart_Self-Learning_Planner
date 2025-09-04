using System;

namespace SmartLearningPlanner.Application.DTOs;

public class UserProfileDto
{
	/// <summary>
	/// Идентификатор пользователя.
	/// </summary>
	public string Id { get; set; }
	/// <summary>
	/// Имя пользователя.
	/// </summary>
	public string FirstName { get; set; }

	/// <summary>
	/// Фамилия пользователя.
	/// </summary>
	public string LastName { get; set; }

	/// <summary>
	/// Email пользователя.
	/// </summary>
	public string Email { get; set; }

	/// <summary>
	/// Username пользователя.
	/// </summary>
	public string UserName { get; set; }

}
