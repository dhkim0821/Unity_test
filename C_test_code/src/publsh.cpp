#include <lcm/lcm-cpp.hpp>
#include "../../lcm-types/cpp/c_test_lcmt.hpp"
#include <stdio.h>
#include <unistd.h>
#include <math.h>

int main(){
    lcm::LCM lcm_c("udpm://239.255.76.67:7667?ttl=255");
    //lcm::LCM lcm_c;
    c_test_lcmt msg;

    double t(0.);
  while(true){
    t += 0.1;
    msg.body_pos[0] = 0.1;
    msg.body_pos[1] = 0.2 + 0.2*sin(0.1*t);
    msg.body_pos[2] = 0.1;

    msg.body_ori[0] = 0.1;
    msg.body_ori[1] = 0.2;
    msg.body_ori[2] = 0.1;

    lcm_c.publish("body_move", &msg );
    printf("sent\n");
    usleep(10000);
  }
  return 0;
}
