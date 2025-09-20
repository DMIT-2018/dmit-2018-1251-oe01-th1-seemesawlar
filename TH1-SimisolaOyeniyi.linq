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