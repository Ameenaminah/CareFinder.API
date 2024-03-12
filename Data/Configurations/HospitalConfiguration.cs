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
    Ownership = "Private",
  },
  new Hospital
  {
    Id = 2,
    Name = "Lagos Executive Cardiovascular Centre",
    Specialization = "Endocrinology",
    Email = "admin@thelecc.com",
    PhoneNumber = "08173651737",
    About = "LECC is a multidisciplinary cardiovascular and cardiac rehabilitation 24/7 facility focused on the treatment and management of cardiovascular diseases and trigger diseases using both invasive and non-invasive procedures, as well as preventive cardiology. Our skilled and experienced cardiologists, vascular and cardiothoraxic surgeons, electrophysiologists, interventional cardiologists and support staff are committed to the treatment and prevention of heart diseases through innovative, state-of-the-art technology. Our support staff include stroke specialists, sleep specialists, endocrinologists (diabetes), nutritionists, physiotherapists, pulmonologists and respiratory physicians.",
    Website = "https://thelecc.com/",
    Ownership = "Private",
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
    Ownership = "Private",
  },
  new Hospital
  {
    Id = 4,
    Name = "Lagos University Teaching Hospital (LUTH)",
    Specialization = "General",
    Email = "info@luth.gov.ng",
    PhoneNumber = "+2348128364824",
    About = "The Lagos University Teaching Hospital today is a foremost tertiary hospital with a mandate to provide excellent services of international standard in patient care, training & research",
    Website = "https://luth.gov.ng/",
    Ownership = "Public",
  },
  new Hospital
  {
    Id = 5,
    Name = "St. Nicholas Hospital",
    Specialization = "General",
    Email = "info@saintnicholashospital.com",
    PhoneNumber = "+2348035251295",
    About = "St. Nicholas Hospital is a private hospital located in Lagos Island in Lagos, Nigeria. It was founded in 1968 by Moses Majekodunmi. The hospital is in a building of the same name located at 57 Campbell Street near Catholic Mission Street. It has other facilities at different locations in Nigeria. Their other locations are: St. Nicholas Hospital, Maryland, St. Nicholas Clinics, Lekki Free Trade Zone, St. Nicholas Clinics, 7b Etim Inyang Street, Victoria Island.",
    Website = "https://saintnicholashospital.com/",
    Ownership = "Private",
  },
  new Hospital
  {
    Id = 6,
    Name = "The Premier Specialists' Medical Centre",
    Specialization = "General",
    Email = "info@thepremiermedical.com",
    PhoneNumber = "08143914895",
    About = "The Premier Specialists’ Medical Centre is the manifestation of a dream to promote the highest possible complete health care service, attainable in the most developed parts of the world, in Nigeria. Premier, as the name implies, means the first among all. We are a specialist hospital whose aim is to serve the healthcare needs of our community by providing quality and  comprehensive health care with the application of modern technology.",
    Website = "https://thepremiermedical.com/",
    Ownership = "Private",
  },
  new Hospital
  {
    Id = 7,
    Name = "Best Care Hospital",
    Specialization = "Gynecology",
    Email = "info@bestcarehospitalng.com",
    PhoneNumber = " 09013617520",
    About = "We are a mother and child friendly, medical and surgical private hospital registered with both Corporate Affairs Commission and Lagos State Private Hospital Registration Authority. We have also been appointed as participating Health Care Service Provider in the National Health Insurance Scheme(CODE LA / 1204 / P) with over Eighteen(18) Health Maintenance Organisation(HMO) registered with us and Nigeria Maritime Administration and Safety Agency(NIMASA).",
    Website = "https://www.bestcarehospitalng.com/",
    Ownership = "Private",
  },
  new Hospital
  {
    Id = 8,
    Name = "Iwosan Lagoon Hospitals",
    Specialization = "General",
    Email = "livemorelife@lagoonhospitals.com",
    PhoneNumber = " +2347080609000",
    About = "Lagoon Hospital was founded in 1986 with its flagship situated at Apapa. Joint Commission International is the world’s leader in healthcare accreditation and the author and evaluator of the most rigorous international standards in quality and patient safety. For consecutive periods, Lagoon Hospitals has earned the Gold Seal of Approval from JCI by demonstrating continuous compliance with international best practices.The feat is a symbol of quality and reflects an organization’s commitment to providing safe and effective patient care. The JCI accreditation provides hospitals with the capacity to improve in various areas particularly with regards to staff education and development to core safety standards.",
    Website = "https://www.lagoonhospitals.com/",
    Ownership = "Private",
  },
  new Hospital
  {
    Id = 9,
    Name = "Etta Atlantic Memorial Hospital",
    Specialization = "General",
    Email = "hello@ettaatlantic.com",
    PhoneNumber = "+234(0)8083734008",
    About = "Atlantic Memorial Hospital Etta - Atlantic Memorial Hospital Lekki Lagos was established with the goal of providing an international level of health care for all Nigerians. Etta - Atlantic Memorial Hospital was established by physicians with training in the US, they have teamed up with bright and dedicated Nigerian physicians and other allied health professionals to provide excellent care based on standards set by the World Health Organization(WHO).",
    Website = "https://www.ettaatlantic.com/",
    Ownership = "Private",
  },
  new Hospital
  {
    Id = 10,
    Name = "Genesis Specialist Hospital",
    Specialization = "General",
    Email = "admin@genesishospitalng.com",
    PhoneNumber = "+2348027340743",
    About = "Atlantic Memorial Hospital Etta - Atlantic Memorial Hospital Lekki Lagos was established with the goal of providing an international level of health care for all Nigerians. Etta - Atlantic Memorial Hospital was established by physicians with training in the US, they have teamed up with bright and dedicated Nigerian physicians and other allied health professionals to provide excellent care based on standards set by the World Health Organization(WHO).",
    Website = "https://genesishospitalng.com/",
    Ownership = "Private",
  },
  new Hospital
  {
    Id = 11,
    Name = "Princess Mary Specialist Hospital",
    Specialization = "Others",
    Email = "info@princessmaryspecialisthospital.com",
    PhoneNumber = "08064063393",
    About = "We are passionate about the healthcare we provide, which is centred around maternal and fetal wellbeing, Obstetric and gynaecological cases. Our aim is to provide our patients with the best possible healthcare service, also as we continually look to improve on our service delivery. Caring for the whole woman",
    Website = "https://www.google.com/maps/place/Princess+Mary+Specialist+Hospital/@5.1240079,7.3938909,17z/data=!3m1!4b1!4m6!3m5!1s0x1042991e2e740205:0x92fc9395cbb85871!8m2!3d5.1240079!4d7.3938909!16s%2Fg%2F11c2k36p3v?entry=ttu",
    Ownership = "Private",
  },
  new Hospital
  {
    Id = 12,
    Name = "Living Word Teaching Hospital",
    Specialization = "Others",
    Email = "info@livingwordweachinghospital.com",
    PhoneNumber = "08062831218",
    About = "Living Word Mission Hospital (LWMH) is a mission established health care institution providing excellent services, quality patient â€“ friendly medical treatments to outright patients.",
    Website = "https://www.google.com/maps/place/Living+Word+Teaching+Hospital/@5.1376132,7.3499621,17z/data=!3m1!4b1!4m6!3m5!1s0x10429bd5db969fc1:0xe7ca643d4f43fec8!8m2!3d5.1376132!4d7.3499621!16s%2Fg%2F11c5dl6bzv?entry=ttu",
    Ownership = "Private",
  }


);
  }
}
