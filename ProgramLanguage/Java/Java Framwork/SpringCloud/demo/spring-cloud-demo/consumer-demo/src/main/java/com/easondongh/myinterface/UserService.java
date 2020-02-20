package com.easondongh.myinterface;

import com.easondongh.domain.User;
import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;

/**
 * @author EasonDongH
 * @date 2020/2/20 9:35
 */
@FeignClient("user-service")
public interface UserService {

    @RequestMapping("/user/{id}")
    User query(@PathVariable("id") Long id);
}
