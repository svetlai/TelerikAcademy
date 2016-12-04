//
//  GSM.h
//  GSM
//
//  Created by s i on 1/26/16.
//  Copyright © 2016 svetlai. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Battery.h"
#import "Display.h"

@interface GSM : NSObject

@property (strong, nonatomic) NSString* model;
@property double price;
@property (strong, nonatomic) NSString* owner;
@property (strong, nonatomic) NSString* manufacturer;
@property (strong, nonatomic) Battery* battery;
@property (strong, nonatomic) Display* display;

-(instancetype)initWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer;
-(instancetype)initWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer andPrice: (double) price;
-(instancetype)initWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer andOwner: (NSString*) owner;

+(GSM*)gsmWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer;
+(GSM*)gsmWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer andPrice: (double) price;
+(GSM*)gsmWithModel: (NSString*) model andManufacturer: (NSString*) manufacturer andOwner: (NSString*) owner;

- (void)setModel:(NSString *)model;
- (void)setManufacturer:(NSString *)manufacturer;

+(GSM*)IPhone5s;

@end
