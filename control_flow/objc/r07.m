#import <Foundation/Foundation.h>
@interface A : NSObject @end
@implementation A
- (int)chain:(int)a {
    if (a == 1) { return 1; } else if (a == 2) { return 2; } else { return 0; }
}
- (int)nested:(int)a {
    if (a == 1) { return 1; } else { if (a == 2) { return 2; } return 0; }
}
- (void)loops:(NSArray *)xs {
    for (int i = 0; i < 3; i++) { }
    for (id x in xs) { }
    while ([xs count] == 0) { break; }
    do { } while (0);
    goto done;
done: ;
}
- (int)sw:(int)a { switch (a) { case 1: return 1; case 2: case 3: return 2; default: return 0; } }
- (void)exc { @try { @throw [NSException new]; } @catch (NSException *e) { } @finally { } }
- (int)tern:(int)a { return a > 0 ? a : -a; }
@end
