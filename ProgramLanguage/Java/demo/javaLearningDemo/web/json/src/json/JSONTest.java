package json;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import domain.Person;
import org.junit.Test;

import java.util.Date;

public class JSONTest {

    @Test
    public void testObjToJson() throws JsonProcessingException {
        Person person = new Person();
        person.setName("张三");
        person.setAge(23);
        person.setBirth(new Date());

        ObjectMapper mapper = new ObjectMapper();
        String s = mapper.writeValueAsString(person);
        System.out.println(s);
    }

    @Test
    public void testJsonToObj() throws Exception {
        ObjectMapper mapper = new ObjectMapper();
        String s = "{\"name\":\"张三\",\"age\":23,\"birth\":\"2019-11-12\"}";
        Person person = mapper.readValue(s, Person.class);
        System.out.println(person);
    }
}
