
# Sepa PTS(PROJECT TRACKING SYSTEM)

## BUILDING A DISTRIBUTED APPLICATION WITH HETEROGENOUS CLIENTS USING .NET AND PYTHON

This is a distributed system that enables SEPA(JENGA school curriculum) students to keep track and access sprint projects in the curriculum. A team leader assigns tasks to the students and keeps track of the projects, an external user can also view the projects and can also pay to access the sprint projects.

# Languages and Tools used
    1.Microsoft Sql Server
    2.C#
    3..Net framework

# Tasks
    1. Setting up database using Microsoft Sql
    2.Creating ERR diagram
    3.Data layer for data access
    4.Business Component-encapsulates the business functionality of the system
    5.Admin GUI
    6..Net Remoting

# Business Component
1.DAO- Provide abstract interfaces to the data sources, contains SQL code for reading and writing to the database
2.Facade Objects-Provides a publicly available interface to the business component, it allows to show each role of user only what they need to see


Roles in the application:
# Admin 
    1.Project set up
    2.Assigning tasks to teams
    3.Updating changes to projects

# Team Leader
    1.Track progress on tasks given
    2.Record completed tasks
    3.Estimate completion date for tasks

# Student
    1.Access Projects
    2.Submit tasked assigned by team leader
    3.Track Project progress



