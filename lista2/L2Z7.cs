//do 6
//tak, bo zawiera wszystkie informacje opisujące działanie systemu (szczegółową implementację)

//do 7
//można złapać ogólną ideę działania systemu, ale prezycję cięzko jest uzyskać
//a na pewno nie jednoznacznie, bo pomija typy i implementację 
//jednak jest to jeden z lepszych sposobów na dzielenie się pomysłem na 
//architekturę systemu

public class Student {
    ICollection<Course> courses; 
    public ICollection<Course> getCourses() {
        return courses;
    }
}

public class UsosWebPage {
    GradeController gcontroller;
    public void show(){
        pageLayout = gcontroller.getStudentGradeInfo();
    }
}

public class GradeController {
    Student student;
    public void getStudentGradeInfo(){
        var courses = student.getCourses();
        var marks = List<int>();
        foreach (var item in courses)
        {
            mark  =  item.getMark(student);   
        }
        return pageLayout;
    }
}

public class Course {
    private Mark getValue() {

    }
    public int getMark(Student student){
        getValue();
    }
}