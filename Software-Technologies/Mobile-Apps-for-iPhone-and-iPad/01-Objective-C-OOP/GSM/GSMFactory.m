//
//  GSMFactory.m
//  GSM
//
//  Created by s i on 1/27/16.
//  Copyright © 2016 svetlai. All rights reserved.
//

#import "GSMFactory.h"
#import "GSM.h"

@implementation GSMFactory
NSMutableArray* gsms;

+(void)fillArrays{
    GSM* samsung = [GSM gsmWithModel:@"S3" andManufacturer:@"Samsung"];
    GSM* nokia = [GSM gsmWithModel:@"1522" andManufacturer:@"Nokia"];
    gsms = [[NSMutableArray alloc] initWithObjects:samsung, nokia, nil];
}
@end
