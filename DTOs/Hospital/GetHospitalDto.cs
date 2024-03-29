﻿using System.ComponentModel.DataAnnotations;
using CareFinder.API.DTOs.Address;

namespace CareFinder.API.DTOs.Hospital;

public class GetHospitalDto : BaseHospitalDto
{
  public int Id { get; set; }

  [Required]
  public ICollection<AddressDto> Addresses { get; set; }
}