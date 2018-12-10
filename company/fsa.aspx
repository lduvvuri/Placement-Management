<%@ Page Title="" Language="C#" MasterPageFile="~/placement management/company/company.master" AutoEventWireup="true" CodeFile="fsa.aspx.cs" Inherits="fs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="fs">
        <h1>FS-Background</h1>
        <p>
            Having started in 2007, KMIT's first batch graduated in the year 2011. With the sole objective of producing industry ready engineering students.
       KMIT has instituted a comprehensive Finishing School program for its Final year students. We believe that this program will go a long way in
       bridging the industry-academia gap that all of us are so well aware of. The Finishing School is run concurrently with the B.Tech course,
    unlike other Finishing schools which are offered after the completion of B.Tech. The modality of conducting the Finishing School is as follows:
        </p>
        <h2>Timmings :</h2>
        <p>
            8:00AM to 1:00PM: Regular University Curriculum<br />
            2:00PM to 6:00PM: Finishing School Curriculum
        </p>
        <h2>Training Program Overview:</h2>
        <p>
            The Finishing School program consists of 2 semesters. The first semester of the Finishing School runs concurrently with the 3rd year
       2nd semester curriculum of JNTU as described above. The 2nd semester runs concurrently with the 4th Year 1st Semester. 
       The student has a choice to opt for various tracks offered.
        </p>
        <h2>Syllabus:</h2>
        <p>Foundation Track: C, C++, Core and Advanced Java, RDBMS, OS fundamentals, Adobe Flex.</p>
        <p>
            Aptitude Skills: Quantitative Techniques, Verbal Ability, Reasoning, Puzzles, General Knowledge, Group Discussion: General Interest,
       Creative topics, Education, Social Topics etc., ELearning: Video Sessions are available online, enabling concept revision.
        </p>
        <h2>Customized Workforce Development:</h2>
        <p>Students undergo one of the following CWD program according to the needs of the recruiting company.</p>
        <p>
            J2EE Track: Spring, Hibernate and Struts
       RIA Track: HTML, CSS and Flex<br />
            Mobile Application Track: JME, iPhone and Android<br />
            Testing Track: ISTQB Certification, Web Application Testing, Mobile Application Testing, Game Testing<br />
            Networking Track: Networking Fundamentals, Linux Server Configuration, Windows Server Configuration, Trouble Shooting.
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <marquee direction="up" loop="true" width="100%" onmouseover="this.stop();" onmouseout="this.start();" style="height: 80%">
             <ul>
                 <li><asp:Label ID="l1" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l2" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l3" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l4" runat="server" Text=""></asp:Label></li>
                 <li><asp:Label ID="l5" runat="server" Text=""></asp:Label></li>
             </ul></marquee>

</asp:Content>

