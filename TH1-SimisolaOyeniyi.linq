<Query Kind="Statements">
  <Connection>
    <ID>336f42d5-3d45-410d-ae1c-04b035a434d8</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>SIMISOLA</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <AlwaysPrefixWithSchemaName>true</AlwaysPrefixWithSchemaName>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>StartTed-2025-Sept (1)</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

//Question 1
ClubActivities
.Where(ca => ca.StartDate.Value >= new DateTime(2025,01,01) 
&& (ca.CampusVenue.Location != "Scheduled Room" && ca.Name != "BTech Club meeting"))
.Select(ca => new
{
 StartDate = ca.StartDate,
 Location = ca.CampusVenue.Location,
 Club = ca.Club.ClubName,
 Activity = ca.Name
} )
.OrderBy(ca => ca.StartDate)
.Dump();


//Question 2
Programs
.Where(p => p.ProgramCourses.Count(pc => pc.Required) >= 22)
.Select(p =>new
{
 School = p.Schools.SchoolName,
 Program = p.ProgramName,
 RequiredCourseCount = p.ProgramCourses.Count(pc => pc.Required),
 OptionalCourseCount = p.ProgramCourses.Count() - p.ProgramCourses.Count(pc => pc.Required)
} )
.OrderBy(p => p.Program)
.Dump();


//Question 3
Students
.Where(s => s.StudentPayments.Count == 0 
&& s.Countries.CountryName.ToUpper() != "CANADA")
.OrderBy(s => s.LastName)
.Select(s => new
{
StudentNumber = s.StudentNumber,
CountryName = s.Countries.CountryName,
FullName = s.FirstName + ' ' + s.LastName,
ClubMembershipCount = s.ClubMembers.Count() == 0 ? "None" : s.ClubMembers.Count().ToString()
})
.Dump();