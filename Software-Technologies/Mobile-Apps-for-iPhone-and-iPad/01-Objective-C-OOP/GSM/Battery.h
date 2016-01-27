//
//  Battery.h
//  GSM
//
//  Created by s i on 1/26/16.
//  Copyright © 2016 svetlai. All rights reserved.
//

#import <Foundation/Foundation.h>

typedef enum
{
    LiIon,
    NiMH,
    NiCd,
} BatteryType;

@interface Battery : NSObject

@property (strong, nonatomic) NSString* model;
@property NSInteger* hoursIdle;
@property NSInteger* hoursITalk;
@property BatteryType* batteryType;


@end
