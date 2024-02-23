using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareFinder.API.Data.Configurations;

public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
{
  public void Configure(EntityTypeBuilder<Hospital> builder)
  {
    builder.HasData(
  new Hospital
  {
    Id = 1,
    Name = "First Cardiology Consultants",
    Specialization = "Cardiology",
    Email = "info@firstcardiology.org",
    PhoneNumber = "08082114266",
    About = "FCC Healthcare is a comprehensive cardiovascular and preventative health care hospital that empowers patients in Nigeria with their health care needs. For over 10 years, we have been delivering the highest quality comprehensive care in Nigeria by innovative use of modern technology and a commitment to local capacity building, education, and collaborative research. We put the patient first, and we have built a healthy medical environment to provide patients with comprehensive care, and deliver excellence in healthcare every day, and not just on some days.",
    Website = "https://firstcardiology.org/",
    Ownership = "Private"
  },
  new Hospital
  {
    Id = 2,
    Name = "Lagos Executive Cardiovascular Centre",
    Specialization = "Endocrinology & Diabetes",
    Email = "admin@thelecc.com",
    PhoneNumber = "08173651737",
    About = "LECC is a multidisciplinary cardiovascular and cardiac rehabilitation 24/7 facility focused on the treatment and management of cardiovascular diseases and trigger diseases using both invasive and non-invasive procedures, as well as preventive cardiology. Our skilled and experienced cardiologists, vascular and cardiothoraxic surgeons, electrophysiologists, interventional cardiologists and support staff are committed to the treatment and prevention of heart diseases through innovative, state-of-the-art technology. Our support staff include stroke specialists, sleep specialists, endocrinologists (diabetes), nutritionists, physiotherapists, pulmonologists and respiratory physicians.",
    Website = "https://thelecc.com/",
    Ownership = "Private"
  },
  new Hospital
  {
    Id = 3,
    Name = "Reddington Hospital",
    Specialization = "General",
    Email = "info@reddingtonhospital.com",
    PhoneNumber = "09165359769",
    About = "Reddington is a 5-star, one-stop facility providing comprehensive solutions to your healthcare needs. The facility was set up as a tertiary centre with multiple specialties, committed to deliver excellent service in the medical field, with all departments supported by the latest technology and state-of-the-art medical equipment.",
    Website = "https://reddingtonhospital.com/",
    Ownership = "Private"
  }
);
  }
}
